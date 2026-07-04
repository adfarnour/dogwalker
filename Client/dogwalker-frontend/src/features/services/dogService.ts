import axios from "axios";
import type { Dog } from "../types/type";

const API_BASE_URL = "http://localhost:5255/api/dog";

export const dogService = {
  getAllDogs: async (): Promise<Dog[]> => {
    const response = await axios.get<Dog[]>(API_BASE_URL);
    return response.data;
  },

  getDogById: async (id: string): Promise<Dog | null> => {
    const response = await axios.get<Dog>(`${API_BASE_URL}/${id}`);
    return response.data;
  },
};
