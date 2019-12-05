class User:
    def __init__(self, name, email):
        self.name = name
        self.email = email
        self.account_balance = 0
    def make_deposit(self, amount):
        self.account_balance += amount
        return self
    def make_withdrawal(self, amount):
        self.account_balance -= amount
        return self
    def transferMoney(self, amount, toWho):
        self.account_balance -= amount
        toWho.account_balance += amount
        print("account balance of person who sent money is", self.account_balance)
        print("account balance of person received money is", toWho.account_balance)
        return self
    def display_user_balance(self):
        print("user:", self.name, "balance:", self.account_balance)
   


Brian = User("Brian", "brian@gmail.com")
Arjun = User("Arjun", "arjun@yahoo.com")
Austin = User("Austin", "austin@aol.com")

# print(Brian.email)

# Brian.make_deposit(1000)
# print("brian's account balance is", Brian.account_balance)
# Brian.display_user_balance()

# Brian.make_deposit(100).make_deposit(100).make_deposit(100)
# print(Brian.account_balance)

# Arjun.make_deposit(200).make_deposit(200).make_withdrawal(50).make_withdrawal(50)
# print(Arjun.account_balance)

# Austin.make_deposit(100).make_withdrawal(25).make_withdrawal(25).make_withdrawal(25)
# print(Austin.account_balance)

# Brian.transferMoney(20, Arjun)
