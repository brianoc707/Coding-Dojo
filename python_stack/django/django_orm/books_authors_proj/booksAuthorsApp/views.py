from django.shortcuts import render, redirect
from .models import Book, Author
from django.contrib import messages

# Create your views here.
def books(request):
	context = {
		"allbooks": Book.objects.all()
	
	}
	return render(request, "books.html", context)

def createbook(request):
	print(request.POST)
	resultFromValidator = Book.objects.validateBook(request.POST)
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
	else:
		newBook = Book.objects.create(title = request.POST['title'])
	return redirect('/books')
def createauthor(request):
	context = {
		'allauthors': Author.objects.all()
	}
	return render(request, "authors.html", context)

def addAuthorToBook(request, bookid):
	print(request.POST)
	authorToAdd = Author.objects.get(id = request.POST['author'])
	book = Book.objects.get(id = bookid)
	book.authors.add(authorToAdd)
	
	return redirect('/bookinfo/' + bookid)

def bookinfo(request, bookid):
	bookToShow =  Book.objects.get(id = bookid)
	context = {
		'book': bookToShow,
		'allauthors': Author.objects.all()
		

	}
	return render(request, "bookinfo.html", context)

def authorsinfo(request, authorid):
	authorToShow = Author.objects.get(id = authorid)
	context = {
		'author' : authorToShow
	}
	return render(request, "authorsinfo.html", context)
