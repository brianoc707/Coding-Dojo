class BankAccount:
	def __init__(self, balance, int_rate):
		self.int_rate = int_rate
		self.balance = balance
	def deposit(self, amount):
		self.balance += amount
		return self
	def withdraw(self, amount):
		self.balance -= amount
		return self
	def display_account_info(self):
		print("Balance:", self.balance, "Interest Rate:", self.int_rate)
		return self
	def yield_interest(self):
		if self.balance > 0:
			self.balance += self.balance * self.int_rate
		else:
			print("Insufficient Funds")
			return self
class User:
	def __init__(self, name, email):
		self.name = name
		self.email = email
		self.account = BankAccount(int_rate=0.02, balance=0)
		self.checking = BankAccount(int_rate=0.0, balance=0)
	


Brian = User("Brian", "brianoc7@gmail.com")

Brian.checking.deposit(100)
Brian.checking.display_account_info()
