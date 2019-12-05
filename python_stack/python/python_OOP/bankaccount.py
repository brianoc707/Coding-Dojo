class BankAccount:
	def __init__(self, name, int_rate):
		self.int_rate = 0.02
		self.account_balance = 0
		self.name = name
	
	def deposit(self, amount):
		self.account_balance += amount
		return self
	def withdraw(self, amount):
		self.account_balance -= amount
	def display_account_info(self):
		print("Member:", self.name, "Balance:", self.account_balance, "Interest Rate:", self.int_rate)
		return self
	def yield_interest(self):
		if self.account_balance > 0:
			self.account_balance += self.account_balance * self.int_rate
		else:
			print("Insufficient Funds")
			return self


Brian = BankAccount("Brian", 0.02,)

Brian.deposit(202)
Brian.display_account_info()
