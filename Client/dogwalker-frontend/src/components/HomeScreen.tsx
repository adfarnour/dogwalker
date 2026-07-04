// src/components/HomeScreen.tsx
import React from "react";
import { useNavigate } from "react-router-dom";

export const HomeScreen: React.FC = () => {
  const navigate = useNavigate();

  return (
    // Flexbox statt Grid: Auf dem Desktop nebeneinander (md:flex-row), auf Mobilgeräten untereinander (flex-col)
    <div className="w-full max-w-4xl min-h-112.5 bg-white rounded-xl shadow-lg border border-gray-200 overflow-hidden flex flex-col md:flex-row">
      {/* Linke Seite: Das große Hundebild */}
      <div className="w-full md:w-2/3 h-64 md:h-112.5">
        <img
          src="./public/images/dogs/bello.jpg"
          alt="Golden Retriever"
          className="w-full h-full object-cover"
        />
      </div>

      {/* Rechte Seite: Titel und die 3 roten Knöpfe */}
      <div className="w-full md:w-1/3 flex flex-col items-center justify-center p-6 bg-white">
        <h1 className="text-red-700 text-center text-3xl font-bold leading-tight mb-8">
          Dog Walkers
          <br />
          United
        </h1>

        <div className="flex flex-col gap-4 w-full px-4">
          <button
            onClick={() => navigate("/bookings")}
            className="w-full bg-red-700 hover:bg-red-800 text-white font-medium py-3 rounded-lg shadow-md transition duration-200"
          >
            See Bookings
          </button>

          <button
            onClick={() => navigate("/trips")}
            className="w-full bg-red-700 hover:bg-red-800 text-white font-medium py-3 rounded-lg shadow-md transition duration-200"
          >
            Manage Trips
          </button>

          <button
            onClick={() => navigate("/dogs")}
            className="w-full bg-red-700 hover:bg-red-800 text-white font-medium py-3 rounded-lg shadow-md transition duration-200"
          >
            View Dogs
          </button>
        </div>
      </div>
    </div>
  );
};
