import React, { useState } from "react";
import { type Dog } from "../features/types/type";

interface DogListSectionProps {
  dogs: Dog[];
  selectedDogId: string | undefined;
  onSelectDog: (dog: Dog) => void;
}

export const DogListSection: React.FC<DogListSectionProps> = ({
  dogs,
  selectedDogId,
  onSelectDog,
}) => {
  const [searchTerm, setSearchTerm] = useState<string>("");

  const filteredDogs = dogs.filter((dog) =>
    dog.name.toLowerCase().includes(searchTerm.toLowerCase()),
  );

  const getCleanImagePath = (
    photoUrl: string | undefined,
    dogName: string,
  ): string => {
    const dbFileName =
      photoUrl && photoUrl.trim() !== ""
        ? photoUrl.split("/").pop() || ""
        : `${dogName}.jpg`;

    const capitalized =
      dbFileName.charAt(0).toUpperCase() + dbFileName.slice(1);
    return `/images/dogs/${capitalized}`;
  };

  return (
    /* Feste Breite von 360px – bewegt sich kein Stück */
    <section className="w-90 shrink-0 border-r border-gray-200 bg-red-50 flex flex-col p-4 h-full">
      {/* Suchfeld */}
      <div className="mb-4">
        <input
          type="text"
          placeholder="Search by name of dog..."
          className="w-full px-4 py-2 border border-red-200 rounded-md bg-white text-sm focus:outline-none focus:ring-2 focus:ring-red-500 shadow-sm"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      {/* Scrollbare Hundeliste */}
      <div className="flex-1 overflow-y-auto space-y-2.5 pr-1">
        {filteredDogs.map((dog) => {
          const imagePath = getCleanImagePath(dog.photoUrl, dog.name);

          return (
            <div
              key={dog.id}
              onClick={() => onSelectDog(dog)}
              className={`flex items-center justify-between p-3 rounded-lg border cursor-pointer transition-all ${
                selectedDogId === dog.id
                  ? "bg-red-200 border-red-400 shadow-sm"
                  : "bg-white border-red-100 hover:bg-red-100"
              }`}
            >
              <div className="flex items-center space-x-4">
                <img
                  src={imagePath}
                  alt={dog.name}
                  className="w-14 h-14 rounded object-cover border border-gray-200 shadow-sm shrink-0"
                  onError={(e) => {
                    e.currentTarget.onerror = null;
                    const fallback = document.createElement("div");
                    fallback.className =
                      "w-14 h-14 rounded bg-red-100 border border-red-200 shadow-sm flex items-center justify-center text-2xl flex-shrink-0";
                    fallback.innerText = "🐾";
                    e.currentTarget.replaceWith(fallback);
                  }}
                />
                <div>
                  <h3 className="font-bold text-gray-900 text-base leading-tight">
                    {dog.name}
                  </h3>
                  <p className="text-xs text-gray-500 mt-0.5">
                    {dog.breed || "Labrador Retriever"}
                  </p>
                </div>
              </div>
              <span className="text-2xl font-bold text-red-600 px-4">
                {dog.gender || "M"}
              </span>
            </div>
          );
        })}
      </div>
    </section>
  );
};
