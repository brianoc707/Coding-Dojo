from django.shortcuts import render, redirect
from .models import *
import bcrypt
from django.contrib import messages

def home(request):

	return render(request, 'home.html')


def register(request):
	print(request.POST)
	resultFromValidator = User.objects.validateUser(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/')
	else:
		passwordFromForm = request.POST['pw']
		hash1 = bcrypt.hashpw(passwordFromForm.encode(), bcrypt.gensalt())
		newUser = User.objects.create(name= request.POST['name'], email = request.POST['email'], password = hash1.decode())
		request.session['loggedinID'] = newUser.id
		return redirect('/quotes')

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
	return redirect('/quotes')





def success(request):
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	quotesFavorited = Quote.objects.filter(favoriters = loggedinUser)
	quotesNotFavorited = Quote.objects.exclude(favoriters = loggedinUser)
	quote = Quote.objects.all()
	context = {
		'loggedinUser': loggedinUser,
		'quotes' : quote,
		'quotesFavorited' : quotesFavorited,
		'quotesNotFavorited' : quotesNotFavorited,
		
	}

	return render(request, 'quotes.html', context)
	
def createQuote(request):
	print(request.POST)
	loggedinUser = User.objects.get(id = request.session['loggedinID'])
	resultFromValidator = Quote.objects.validateQuote(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/quotes')
	else:
		newQuote = Quote.objects.create(poster = loggedinUser, quoter = request.POST['quoter'], message = request.POST['message'])
	
	
	return redirect('/quotes')

def count(request, userid):
	user = User.objects.get(id = userid)
	loggedinUser = User.objects.get(id =request.session['loggedinID'])
	count = len(Quote.objects.filter(poster = userid))
	quotes = Quote.objects.filter(poster = userid)
	context = {
		'loggedinUser': loggedinUser,
		'user' : user,
		'quotes' : quotes,
		'count' : count,
	}
	return render(request,'count.html', context)

def edit(request, quoteid):
	context = {
		'quote' : Quote.objects.get(id = quoteid)
	}
	return render(request, 'edit.html', context)

def update(request, quoteid):
	resultFromValidator = Quote.objects.validateUpdate(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
		return redirect('/quotes/' + str(quoteid))
	else:
		quote = Quote.objects.get(id = quoteid)
		quote.quoter = request.POST['quoter']
		quote.message = request.POST['message']
		quote.save()
		return redirect('/quotes')

def delete(request, quoteid):
	quote = Quote.objects.get(id = quoteid)
	quote.delete()
	return redirect('/quotes')

def favorite(request, quoteid):
	favoriter = User.objects.get(id = request.session['loggedinID'])
	quote = Quote.objects.get(id = quoteid)
	favoriter.favorites.add(quote)
	return redirect('/quotes')

def remove(request, quoteid):
	favoriter = User.objects.get(id = request.session['loggedinID'])
	quote = Quote.objects.get(id = quoteid)
	favoriter.favorites.remove(quote)
	return redirect('/quotes')


def dashboard(request):
	return redirect('/quotes')

def logout(request):
	request.session.clear()
	return redirect('/')