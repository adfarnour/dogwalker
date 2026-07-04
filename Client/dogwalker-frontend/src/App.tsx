import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./App.css";
import { HomeScreen } from "./components/HomeScreen";
import { ViewDogs } from "./components/ViewDogs";

// Platzhalter-Komponenten für den ersten Start
const BookingsPlaceholder = () => (
  <div className="p-6">🗓️ Bookings Galerie (Demnächst)</div>
);
const TripsPlaceholder = () => (
  <div className="p-6">🚗 Trips Verwaltung (Demnächst)</div>
);

const router = createBrowserRouter([
  {
    path: "/",
    element: <HomeScreen />,
  },
  {
    path: "/bookings",
    element: <BookingsPlaceholder />,
  },
  {
    path: "/trips",
    element: <TripsPlaceholder />,
  },
  {
    path: "/dogs",
    element: <ViewDogs />,
  },
]);
function App() {
  return (
    <div className="bg-gray-100 min-h-screen w-screen flex items-center justify-center p-4">
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
