export interface Trip {
  id: string;
  date: string;
  walkerName: string;
  durationMinutes: number;
  rating: number;
  imageUrl?: string;
}

export interface Dog {
  id: string;
  name: string;
  breed: string;
  gender: "M" | "F";
  ownerName: string;
  ownerEmail: string;
  ownerAddress: string;
  photoUrl: string;
  trips: Trip[];
}

export interface DogDetails {
  id: string;
  name: string;
  breed: string;
  gender: string;
  photoUrl: string;
  ownerId: string;
  ownerName: string;
  ownerEmail: string;
  ownerAddress: string; // Neu für die Google-Maps-Route
  upcomingTrips: Trip[]; // Die Liste der Trips für die 3. Spalte
}
