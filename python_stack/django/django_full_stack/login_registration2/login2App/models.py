from django.db import models
import re
import bcrypt

class userManager(models.Manager):
	def validateUser(self, postData):
		print(postData)
		errors = {}
		if len(postData['fname']) < 2:
			errors['fname'] = "First Name must be longer than 2 characters"
		if len(postData['lname']) < 2:
			errors['lname'] =  "Last Name must be longer than 2 characters"
		EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
		if not EMAIL_REGEX.match(postData['email']):           
			errors['email'] = "Invalid email address!"
		if len(postData['pw']) < 8:
			errors['pw'] = "Must enter a valid password"

		print(errors)
		return(errors)

	def loginValidator(self, postData):
		errors= {}
		print(postData)
		potato = User.objects.filter(email = postData['email'])
		if len(potato) == 0:
			errors['email'] = "User does not exist"
		
		# print('******')
		# print(potato)
		# print('******')
		else:
			user1 = potato[0]
			print(user1.password)
			if not bcrypt.checkpw(postData['pw'].encode(), user1.password.encode()):
				errors['password'] = "incorrect password"
			
			
		print(errors)
		return errors


class User(models.Model):
	first_name = models.CharField(max_length = 255)
	last_name = models.CharField(max_length = 255)
	email = models.CharField(max_length = 255)
	password = models.CharField(max_length = 255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = userManager()
	
