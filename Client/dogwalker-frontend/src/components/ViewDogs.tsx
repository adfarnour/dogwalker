import React, { useEffect, useState } from "react";
import type { Dog, DogDetails } from "../features/types/type";
import { dogService } from "../features/services/dogService";
import { DogListSection } from "./DogListSection";
import { DogTripsSection } from "./DogTripsSection"; // Neue Komponente importieren

export const ViewDogs: React.FC = () => {
  const [dogs, setDogs] = useState<Dog[]>([]);
  const [selectedDogDetails, setSelectedDogDetails] =
    useState<DogDetails | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchInitialDogs = async () => {
      try {
        setLoading(true);
        const data = await dogService.getAllDogs();
        setDogs(data);
        if (data.length > 0) {
          handleSelectDog(data[0]);
        }
      } catch (err) {
        setError("Fehler beim Laden der Hundeliste.");
        console.error(err);
      } finally {
        setLoading(false);
      }
    };
    fetchInitialDogs();
  }, []);

  const handleSelectDog = async (dog: Dog) => {
    try {
      const details = await dogService.getDogById(dog.id);
      setSelectedDogDetails(details);
    } catch (err) {
      console.error("Fehler beim Laden der Hundedetails:", err);
    }
  };

  const getCleanImagePath = (
    photoUrl: string | undefined,
    name: string | undefined,
  ): string => {
    const dogName = name || "Bello";
    const dbFileName =
      photoUrl && photoUrl.trim() !== ""
        ? photoUrl.split("/").pop() || ""
        : `${dogName}.jpg`;

    const capitalized =
      dbFileName.charAt(0).toUpperCase() + dbFileName.slice(1);
    return `/images/dogs/${capitalized}`;
  };

  const renderStars = (rating: number) => {
    return Array.from({ length: 5 }, (_, i) => (
      <span
        key={i}
        className={
          i < rating ? "text-red-600 text-xl" : "text-gray-300 text-xl"
        }
      >
        ★
      </span>
    ));
  };

  if (loading)
    return (
      <div className="p-8 text-center text-gray-600 font-bold">
        Hunde werden geladen...
      </div>
    );
  if (error)
    return (
      <div className="p-8 text-center text-red-600 font-bold">{error}</div>
    );

  return (
    <div className="flex flex-col h-screen w-full bg-gray-300 font-sans select-none overflow-hidden">
      {/* Rote Top-Bar */}
      <header className="bg-red-700 text-white px-8 py-3 flex justify-between items-center shadow-md flex-shrink-0 w-full">
        <h1 className="text-4xl font-bold tracking-wide">Dogs</h1>
        <div className="flex space-x-6 text-3xl">
          <button className="hover:text-red-200 transition-colors transform scale-x-[-1]">
            ↶
          </button>
          <button className="hover:text-red-200 transition-colors">🏠</button>
        </div>
      </header>

      {/* Zentrierter Hauptkasten */}
      <main className="flex-1 p-6 flex justify-center items-start overflow-hidden">
        <div className="bg-white w-full max-w-6xl h-full rounded-sm shadow-xl flex flex-col overflow-hidden border border-gray-400">
          {/* Feste, gemeinsame Überschriften-Zeile */}
          <div className="flex border-b border-gray-200 py-4 flex-shrink-0">
            <div className="w-1/3 text-center font-bold text-red-700 text-2xl tracking-wide">
              List of Dogs
            </div>
            <div className="w-1/3 text-center font-bold text-red-700 text-2xl tracking-wide">
              Profile
            </div>
            <div className="w-1/3 text-center font-bold text-red-700 text-2xl tracking-wide">
              Trips
            </div>
          </div>

          {/* Inhalt unterhalb der Überschriften */}
          <div className="flex flex-1 overflow-hidden">
            {/* SPALTE 1: Liste */}
            <DogListSection
              dogs={dogs}
              selectedDogId={selectedDogDetails?.id}
              onSelectDog={handleSelectDog}
            />

            {/* SPALTE 2: Profile */}
            <section className="w-1/3 border-r border-gray-100 flex flex-col p-6 items-center overflow-y-auto">
              {selectedDogDetails ? (
                <div className="w-full flex flex-col items-center">
                  <div className="w-64 h-48 bg-gray-50 rounded-sm overflow-hidden border border-gray-200 shadow-sm mb-4 flex items-center justify-center flex-shrink-0">
                    <img
                      src={getCleanImagePath(
                        selectedDogDetails.photoUrl,
                        selectedDogDetails.name,
                      )}
                      alt={selectedDogDetails.name}
                      className="w-full h-full object-cover"
                      onError={(e) => {
                        e.currentTarget.onerror = null;
                        const parent = e.currentTarget.parentElement;
                        if (parent)
                          parent.innerHTML =
                            '<span class="text-6xl text-red-400">🐾</span>';
                      }}
                    />
                  </div>

                  <h3 className="text-4xl text-red-700 font-medium mb-4">
                    {selectedDogDetails.name}
                  </h3>

                  <div className="flex justify-between w-full max-w-xs text-sm text-gray-600 mb-6 px-2 font-medium">
                    <span>{selectedDogDetails.breed || "Bulldogs"}</span>
                    <span>
                      {(selectedDogDetails.gender || "M") === "M"
                        ? "Male"
                        : "Female"}
                    </span>
                  </div>

                  <div className="w-full max-w-xs space-y-3.5 text-sm pt-2">
                    <div className="flex justify-between items-start">
                      <span className="text-gray-900 font-bold whitespace-nowrap mr-4">
                        Owner's Name
                      </span>
                      <span className="text-gray-600 text-right">
                        {selectedDogDetails.ownerName || "Jasmine Richards"}
                      </span>
                    </div>
                    <div className="flex justify-between items-start">
                      <span className="text-gray-900 font-bold whitespace-nowrap mr-4">
                        Owner's Email
                      </span>
                      <span className="text-gray-600 text-right break-all">
                        {selectedDogDetails.ownerEmail ||
                          "Jasmine.Richards@gmail.com"}
                      </span>
                    </div>
                    <div className="flex justify-between items-start">
                      <span className="text-gray-900 font-bold whitespace-nowrap mr-4">
                        Owner's Address
                      </span>
                      <span className="text-gray-600 text-right leading-tight max-w-[180px]">
                        {selectedDogDetails.ownerAddress ||
                          "7240 Bear Hill St. Brooklyn, NY 11225"}
                      </span>
                    </div>
                  </div>

                  <div className="flex space-x-4 w-full max-w-xs mt-8">
                    <button
                      onClick={() =>
                        (window.location.href = `mailto:${selectedDogDetails.ownerEmail}`)
                      }
                      className="flex-1 bg-red-700 hover:bg-red-800 text-white font-bold py-2 px-3 rounded-md shadow-md text-sm transition-colors"
                    >
                      Email Owner
                    </button>
                    <button
                      onClick={() =>
                        window.open(
                          `https://google.com{encodeURIComponent(selectedDogDetails.ownerAddress || '')}`,
                          "_blank",
                        )
                      }
                      className="flex-1 bg-red-700 hover:bg-red-800 text-white font-bold py-2 px-3 rounded-md shadow-md text-sm transition-colors"
                    >
                      Route Address
                    </button>
                  </div>
                </div>
              ) : (
                <p className="text-gray-400 mt-10">Wähle einen Hund aus.</p>
              )}
            </section>

            {/* HIER WIRD SPALTE 3 REINGELADEN */}
            <DogTripsSection
              selectedDogDetails={selectedDogDetails}
              renderStars={renderStars}
            />
          </div>
        </div>
      </main>
    </div>
  );
};
