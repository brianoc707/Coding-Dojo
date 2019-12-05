from django.db import models
import bcrypt
from datetime import datetime
from datetime import date

class UserManager(models.Manager):
	def validateUser(self, postData):
		errors = {}
		unameRegistered = User.objects.filter(username = postData['uname'])
		if len(postData['name']) < 3:
			errors['fname'] = 'First Name must be at least 3 characters'		
		if len(postData['pw']) < 8:
			errors['pw'] = "Password must be at least 8 characters"
		if postData['pw'] != postData['cpw']:
			errors['match'] = 'Passwords do not match'
		if len(unameRegistered) > 0:
			errors['unameexists'] = 'Username already taken'
		
		return errors
	def loginValidator(self, postData):
		errors = {}
		unameRegistered = User.objects.filter(username = postData['uname'])
		print('****')
		print(unameRegistered)
		print('****')
		if len(unameRegistered)  == 0:
			errors['unamemnotfound'] = 'This username is not registered'
		else:
			user = unameRegistered[0]
			if bcrypt.checkpw(postData['pw'].encode(), user.password.encode()):
				print("password match")
			else:
				print("failed password")
				errors['pw'] = 'Invalid password'
		return errors

class TripManager(models.Manager):
	def validateTrip(self, postData):
		errors = {}
		if len(postData['dest']) == 0:
			errors['dest'] = 'You must enter a destination'
		if len(postData['desc']) == 0:
			errors['desc'] = 'You must enter a description'
		if postData['from'] < str(date.today()):
			errors['from'] = 'Date must be in the future'
		if postData['to'] <= postData['from']:
			errors['to'] = 'Date must be after the start date'
		if len(postData['from']) < 1:
			errors['from'] = 'Please enter a date'
		if len(postData['to']) < 1:
			errors['to'] = 'Please enter a date'
		return errors




class User(models.Model):
	name = models.CharField(max_length = 255)
	username = models.CharField(max_length = 255)
	password = models.CharField(max_length = 255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = UserManager()

class Trip(models.Model):
	destination = models.CharField(max_length = 255)
	creator = models.ForeignKey(User, related_name = 'trip', on_delete = models.CASCADE)
	joiner = models.ManyToManyField(User, related_name = 'trips')
	plan = models.CharField(max_length = 255)
	start_date = models.DateField()
	end_date = models.DateField()
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = TripManager()




