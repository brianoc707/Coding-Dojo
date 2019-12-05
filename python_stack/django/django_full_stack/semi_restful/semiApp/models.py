from django.db import models


# Create your models here.
class ShowManager(models.Manager):
	def validateShow(self, postData):
		print('we are in the show manager validator ')
		print(postData)
		errors = {}
		if len(postData['title']) < 2:
			errors['title'] = "Show name should be at least 2 characters"
		if len(postData['network']) < 3:
			errors['network'] = "Show network should be at least 3 characters"
		if len(Show.objects.filter(title= postData['title'])) > 0:
			errors['title'] = "Show Already Exists"
			
		print(errors)
		return errors

class Show(models.Model):
	title = models.CharField(max_length = 255)
	network = models.CharField(max_length = 255)
	release_date = models.DateField()
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	objects = ShowManager()