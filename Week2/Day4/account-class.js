"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Account {
    owner;
    balance;
    accountType;
    id;
    constructor(owner, id, initial = 0) {
        this.owner = owner;
        this.id = id;
        this.balance = initial;
        this.accountType = 'basic';
    }
    deposit(amount) {
        this.balance += amount;
    }
    getBalance() {
        return this.balance;
    }
}
const acc = new Account('Atibali', 10, 500);
console.log(acc.getBalance());
//# sourceMappingURL=account-class.js.map