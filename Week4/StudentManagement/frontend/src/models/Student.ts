export interface Student {
  _id: string;
  name: string;
  email: string;
  course: string;
}

export type CreateStudentDto = Omit<Student, "_id">;
