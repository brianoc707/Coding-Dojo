from django.shortcuts import render, redirect
from django.contrib import messages
from django.db.models import Q
from .models import User, Trip
import bcrypt

# Create your views here.
def main(request):

	return render(request, 'main.html')

def register(request):
	print(request.POST)
	resultFromValidator = User.objects.validateUser(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		
		pwFromForm = request.POST['pw']
		hash1 = bcrypt.hashpw(pwFromForm.encode(), bcrypt.gensalt())
		newUser = User.objects.create(name= request.POST['name'], username = request.POST['uname'], password = hash1.decode())
		request.session['loggedinID'] = newUser.id
		return redirect('/travels')

def login(request):
	print(request.POST)
	resultFromValidator = User.objects.loginValidator(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		user = User.objects.get(username = request.POST['uname'])
		request.session['loggedinID'] = user.id
	return redirect('/travels')


def travels(request):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
    # accounts = Account.objects.filter(Q(account_type=3) | Q(account_type=4))
	myTripScheduled = Trip.objects.filter(Q(creator = loggedinUser ) | Q(joiner = loggedinUser))
	otherTripScheduled = Trip.objects.exclude(Q(creator = loggedinUser ) | Q(joiner = loggedinUser))
	context = {
		'loggedinUser' : loggedinUser,
		'myTripScheduled' : myTripScheduled,
		'otherTripScheduled' : otherTripScheduled,
	}
	return render(request, 'travels.html', context)

def newTrip(request):

	return render(request, 'newtrip.html')

def join(request, tripid):
	joiner = User.objects.get(id = request.session['loggedinID'])
	trip = Trip.objects.get(id = tripid)
	joiner.trips.add(trip)

	return redirect('/travels')



def createTrip(request):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	print(request.POST)
	errors = Trip.objects.validateTrip(request.POST)
	if len(errors) > 0:
		for key, value in errors.items():
			messages.error(request, value)
		return redirect('/travels/add')
	else:
		trip = Trip.objects.create(destination = request.POST['dest'], creator = loggedinUser, plan = request.POST['desc'], start_date = request.POST['from'], end_date = request.POST['to'])
		print(trip)
		return redirect('/travels')

def info(request, tripid):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	myTripScheduled = Trip.objects.filter(creator = loggedinUser)
	otherTripScheduled = Trip.objects.exclude(creator = loggedinUser)
	trip = Trip.objects.get(id = tripid)
	context = {
		"myTripScheduled" : myTripScheduled,
		'otherTripScheduled' : otherTripScheduled,
		'trip' : trip,
	}
	return render(request, 'info.html', context)

def home(request):

	return redirect('/travels')  
	



def logout(request):
	request.session.clear()
	return redirect('/')

