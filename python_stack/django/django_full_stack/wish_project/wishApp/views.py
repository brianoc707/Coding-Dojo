from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *
import bcrypt


# Create your views here.
def index(request):
	
	return render(request, 'index.html')

def register(request):
	print(request.POST)
	resultFromValidator = User.objects.validateUser(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		#if the request.POST info is valid then create a new user w the info from the form
		#encrypt the pw
		pwFromForm = request.POST['pw']
		hash1 = bcrypt.hashpw(pwFromForm.encode(), bcrypt.gensalt())
		newUser = User.objects.create(first_name= request.POST['fname'], last_name = request.POST['lname'], email = request.POST['email'], password = hash1.decode())
		#save the info of the new user in session
		request.session['loggedinID'] = newUser.id
		return redirect('/success')

def login(request):
	print(request.POST)
	resultFromValidator = User.objects.loginValidator(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		user = User.objects.get(email = request.POST['email'])
		request.session['loggedinID'] = user.id
	return redirect('/success')

	

def success(request):
	if 'loggedinID' not in request.session:
		return redirect('/')
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	wishesNotGranted = Wish.objects.filter(user = loggedinUser, isgranted = False)
	allgrantedwishes = Wish.objects.filter(isgranted = True)
	print(wishesNotGranted)
	context = {
		'loggedinUser' : loggedinUser,
		'myWishesNotGranted' : wishesNotGranted,
		'allGrantedWishes' : allgrantedwishes,
		
	}
	

	return render(request, 'wishes.html', context)

def newWish(request):
	
	return render(request, 'newwish.html')

def createWish(request):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	print(request.POST)
	errors = Wish.objects.wishValidator(request.POST)
	if len(errors) > 0:
		for key, value in errors.items():
			messages.error(request, value)
		return redirect('/wishes/new')
	else:
		wish = Wish.objects.create(item = request.POST['item'], user = loggedinUser, likes = 0, desc = request.POST['desc'])
		print(wish)
		return redirect('/success')

def grant(request, wishid):
	wish = Wish.objects.get(id = wishid)
	wish.isgranted = True
	wish.save()
	return redirect('/success')

def like(request, wishid):
	wish = Wish.objects.get(id = wishid)
	wish.likes += 1
	wish.save()
	return redirect('/success')

def edit(request, wishid):
	context = {
		'wish' : Wish.objects.get(id = wishid)
	}
	return render(request, 'edit.html', context)

def update(request, wishid):
	wish = Wish.objects.get(id = wishid)
	wish.item = request.POST['item']
	wish.desc = request.POST['desc']
	wish.save()
	
def stats(request):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	allgrantedwishescount = len(Wish.objects.filter(isgranted = True))
	mygrantedwishescount = len(Wish.objects.filter(user = loggedinUser, isgranted = True))
	myungranted = len(Wish.objects.filter(user = loggedinUser, isgranted = False))
	context = {
		'loggedinUser' : loggedinUser,
		'countofgranted': allgrantedwishescount,
		'mycount' : mygrantedwishescount,
		'myungranted' : myungranted,
	}
	return render(request, 'stats.html', context)

def logout(request):
	request.session.clear()
	return redirect('/')
