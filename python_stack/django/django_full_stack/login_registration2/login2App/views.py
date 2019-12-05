from django.shortcuts import render, redirect
from .models import User
from django.contrib import messages
import bcrypt

def home(request):


	return render(request, 'home.html')

def signUp(request):
	resultFromValidator = User.objects.validateUser(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		passwordFromForm = request.POST['pw']
		print(passwordFromForm)
		hash1 = bcrypt.hashpw(passwordFromForm.encode(), bcrypt.gensalt())
		print(hash1)
		newUser = User.objects.create(first_name =request.POST['fname'], last_name = request.POST['lname'], email = request.POST['email'], password = request.POST['pw'])
		print(newUser)
		request.session['email'] = newUser.email
		return redirect('/success')

def login(request):
	
	email = request.POST['email']
	user = User.objects.get(email = email)
	print(user.password)
	

	#send the request.post to a login validator in models
	errors = User.objects.loginValidator(request.POST)
	if len(errors) > 0:
		for key, value in errors.items():
			messages.error(request, value)
		return redirect('/')
	else:
		request.session['email'] = email
		return redirect('/success')



def success(request):
	loggedInUser = User.objects.get(email = request.session['email'])
	print("in the login function")
	print(loggedInUser)
	context = {
		'currentUser' : loggedInUser
	}
	
	return render(request, 'success.html', context)

def logout(request):
	request.session.clear()

	return redirect('/home')


