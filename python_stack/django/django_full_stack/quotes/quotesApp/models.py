from django.db import models
import bcrypt
import re

class UserManager(models.Manager):
	def validateUser(self, postData):
		errors = {}
		emailRegistered = User.objects.filter(name = postData['email'])
		if len(postData['name']) < 3:
			errors['name'] = 'Name must be at least 3 characters'		
		if len(postData['pw']) < 8:
			errors['pw'] = "Password must be at least 8 characters"
		if postData['pw'] != postData['cpw']:
			errors['match'] = 'Passwords do not match'
		EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
		if not EMAIL_REGEX.match(postData['email']):           
			errors['email'] = "Invalid email address!"
		if len(emailRegistered) > 0:
			errors['emailexists'] = 'Email already taken'
		
		return errors


	def loginValidator(self, postData):
		errors= {}
		print(postData)
		potato = User.objects.filter(email = postData['email'])
		if len(potato) == 0:
			errors['email'] = "Must enter an email address"
		else:
			user1 = potato[0]
			print(user1.password)
			if not bcrypt.checkpw(postData['pw'].encode(), user1.password.encode()):
				errors['password'] = "incorrect password"
			
			
		print(errors)
		return errors

class QuoteManager(models.Manager):
	
	def validateQuote(self, postData):
		errors = {}
		if len(postData['quoter']) == 0:
			errors['quoter'] = 'You must Enter a Name'
		if len(postData['message']) == 0:
			errors['message'] = 'Please enter a quote'
		
		return errors
	
	def validateUpdate(self, postData):
		errors = {}
		if len(postData['quoter']) == 0:
			errors['quoter'] = 'You must Enter a Name'
		if len(postData['message']) == 0:
			errors['message'] = 'Please enter a quote'
		
		return errors
		

class User(models.Model):
	name = models.CharField(max_length = 255)
	username = models.CharField(max_length = 255)
	email = models.EmailField(max_length = 70, blank = False)
	password = models.CharField(max_length = 255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = UserManager()


class Quote(models.Model):
	quoter = models.CharField(max_length = 255)
	poster = models.ForeignKey(User, related_name = 'quote_created', on_delete = models.CASCADE)
	favoriters = models.ManyToManyField(User, related_name = 'favorites')
	message = models.CharField(max_length = 255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = QuoteManager()

