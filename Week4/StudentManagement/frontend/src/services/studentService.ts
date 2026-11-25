import apiClient from "../api/apiClient";
import type { CreateStudentDto, Student } from "../models/Student";

export const studentService = {
  getAll: async (): Promise<Student[]> => {
    const response = await apiClient.get<Student[]>("/students");
    return response.data;
  },

  create: async (student: CreateStudentDto): Promise<Student> => {
    const response = await apiClient.post<Student>("/students", student);
    return response.data;
  },
};