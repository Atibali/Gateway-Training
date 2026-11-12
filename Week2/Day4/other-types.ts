// Enums
enum Color {
    Red,
    Green,
    Blue
}
enum Status {
    Pending= 'P',
    Success= 'S',
    Error= 'E'
}
console.log(Status.Success);
console.log(Color.Blue)


function identityAny(arg: any):any {
    return arg;
}
// Generics
function identity<T>(arg: T): T {
    return arg;
}
const s1=identityAny('Hello')
const n1=identityAny(44);
const s2=identity('Hello')
const n2=identity(44);
console.log(`Type of s1: ${typeof(s1)}`);
console.log(`Type of s2: ${typeof(s2)}`);
console.log(`Type of n1: ${typeof(n1)}`);
console.log(`Type of n2: ${typeof(n2)}`);
// Demonstrating type safety
s2.toUpperCase(); // Valid: TypeScript knows s2 is string
// s1.toUpperCase(); // Also allowed, but TypeScript cannot verify it safely

function firstItem<T>(arr: T[]): T | undefined {
    return arr[0];
}
console.log(firstItem([1,3,5]));

interface Box<t> {
    value: t;
}
const stringBox: Box<string> = {value: 'Hello World'};
console.log(stringBox.value);


// Type Narrowing
function format(value: string | number): string {
    if(typeof value=='string') {
        return value.toUpperCase();
    }
    return value.toFixed(2);
}
console.log(format("Jacob is great"));
console.log(format(1007));

// Null checks
function length(s: string | null): number {
  if (s === null) return 0;
  return s.length;                // narrowed to string
}
console.log(length(null));

// Custom Type Guard
function isString(v: unknown): v is string {
    return typeof v==='string';
}
console.log(isString(7.8));

// Utility Types
interface User {
    id: number,
    name: string,
    email: string
}

// Partial<T> — all properties optional
function updateUser(id: number, changes: Partial<User>) {}
updateUser(1,({name: 'Bobby'}));

// Pick<T, K> — choose a subset of properties
type UserSummary = Pick<User, 'id' | 'name'>;
const s: UserSummary = { id: 1, name: 'Alice' };

// Omit<T, K> — exclude properties
type UserWithoutEmail = Omit<User, 'email'>;
const u: UserWithoutEmail = { id: 1, name: 'Alice' };

// Common combinations
type UserUpdate = Partial<Omit<User, 'id'>>; // editable fields, all optional