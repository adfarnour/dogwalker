import React from "react";
import { type DogDetails } from "../features/types/type";

interface DogTripsSectionProps {
  selectedDogDetails: DogDetails | null;
  renderStars: (rating: number) => React.ReactNode;
}

export const DogTripsSection: React.FC<DogTripsSectionProps> = ({
  selectedDogDetails,
  renderStars,
}) => {
  return (
    <section className="w-1/3 flex flex-col p-6 overflow-y-auto">
      {selectedDogDetails &&
      selectedDogDetails.upcomingTrips &&
      selectedDogDetails.upcomingTrips.length > 0 ? (
        <div className="space-y-6 w-full">
          {selectedDogDetails.upcomingTrips.map((trip) => (
            <div key={trip.id} className="flex space-x-4 items-center">
              {/* Kleines Trip-Bild */}
              <div className="w-24 h-16 bg-gray-100 border rounded-sm overflow-hidden flex-shrink-0">
                <img
                  src="/images/dogs/Gassi.jpg"
                  alt="Trip"
                  className="w-full h-full object-cover"
                  onError={(e) => {
                    e.currentTarget.src = "https://placeholder.com🌳";
                  }}
                />
              </div>
              {/* Trip Infos */}
              <div className="flex-1 flex justify-between items-center">
                <div>
                  <p className="font-bold text-gray-900 text-lg">{trip.date}</p>
                  <p className="text-sm text-gray-500">{trip.walkerName}</p>
                  <div className="flex space-x-0.5 mt-1">
                    {renderStars(trip.rating)}
                  </div>
                </div>
                <span className="font-bold text-gray-800 text-lg mr-2">
                  {trip.durationMinutes}
                </span>
              </div>
            </div>
          ))}
        </div>
      ) : (
        /* Dummy-Trips exakt wie auf dem Kurs-Screenshot als Vorschau */
        <div className="space-y-6 w-full">
          <div className="flex space-x-4 items-center">
            <div className="w-24 h-16 bg-gray-200 rounded-sm overflow-hidden flex-shrink-0">
              <span className="flex h-full w-full items-center justify-center text-2xl">
                🦮
              </span>
            </div>
            <div className="flex-1 flex justify-between items-center">
              <div>
                <p className="font-bold text-gray-900 text-lg">5/8/2022</p>
                <p className="text-sm text-gray-500">Brad Pitt</p>
                <div className="flex space-x-0.5 mt-1">{renderStars(4)}</div>
              </div>
              <span className="font-bold text-gray-800 text-lg mr-2">15</span>
            </div>
          </div>

          <div className="flex space-x-4 items-center">
            <div className="w-24 h-16 bg-gray-200 rounded-sm overflow-hidden flex-shrink-0">
              <span className="flex h-full w-full items-center justify-center text-2xl">
                🐕
              </span>
            </div>
            <div className="flex-1 flex justify-between items-center">
              <div>
                <p className="font-bold text-gray-900 text-base">5/13/2022</p>
                <p className="text-sm text-gray-500">Henry Habib</p>
                <div className="flex space-x-0.5 mt-1">{renderStars(5)}</div>
              </div>
              <span className="font-bold text-gray-800 text-lg mr-2">60</span>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};
