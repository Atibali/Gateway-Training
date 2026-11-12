class Account {
    public owner: string;
    private balance: number;
    protected accountType: string;
    readonly id: number;

    constructor(owner: string,id: number,initial=0) {
        this.owner=owner;
        this.id=id;
        this.balance=initial;
        this.accountType='basic';
    }

    deposit(amount: number): void {
        this.balance+=amount;
    }
    getBalance(): number {
        return this.balance;
    }
}
const acc=new Account('Atibali',10,500);
console.log(acc.getBalance());