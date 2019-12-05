from django.db import models
import re
import bcrypt

class UserManager(models.Manager):
	def validateUser(self, postData):
		errors = {}
		if len(postData['fname']) < 1:
			errors['fname'] = 'First name must be longer than 1 character'
		if len(postData['lname']) < 1:
			errors['lname'] = 'Last name must be longer than 1 character'
		EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
		if not EMAIL_REGEX.match(postData['email']):           
			errors['emailpattern'] = ("Invalid email address!")
		if len(postData['pw']) < 8:
			errors['pw'] = "Must enter a valid password"
		if postData['pw'] != postData['cpw']:
			errors['match'] = 'passwords do not match'
		#validate that email is not already taken
		emailTaken = User.objects.filter(email = postData['email'])
		print(emailTaken)
		if len(emailTaken) > 0:
			errors['emailTaken'] = 'email already exists'
	
		
		return errors

	def loginValidator(self, postData):
		errors = {}
		emailRegistered = User.objects.filter(email = postData['email'])
		print('****')
		print(emailRegistered)
		print('****')
		if len(emailRegistered)  == 0:
			errors['emailnotfound'] = 'this email is not registered'
		else:
			user = emailRegistered[0]
		if bcrypt.checkpw(postData['pw'].encode(), user.password.encode()):
			print("password match")
		else:
			print("failed password")
			errors['pw'] = 'invalid password'
		return errors

class WishManager(models.Manager):
	def wishValidator(self, postData):
		errors = {}
		if len(postData['item']) < 1:
			errors['item'] = 'you must enter an item'
		if len(postData['desc']) < 1:
			errors['desc'] = 'you must enter info'
		return errors


		
class User(models.Model):
	first_name = models.CharField(max_length = 255)
	last_name = models.CharField(max_length = 255)
	email = models.CharField(max_length = 255)
	password = models.CharField(max_length = 255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = UserManager()

class Wish(models.Model):
	item = models.CharField(max_length = 255)
	user = models.ForeignKey(User, related_name = 'wishes', on_delete = models.CASCADE)
	likes = models.IntegerField(default = 0)
	desc = models.CharField(max_length = 255)
	isgranted = models.BooleanField(default = False)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = WishManager()
