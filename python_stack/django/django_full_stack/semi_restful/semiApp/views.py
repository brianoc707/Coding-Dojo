from django.shortcuts import render, redirect
from .models import Show
from django.contrib import messages
# Create your views here.
def home(request):
	context = {
		'allShows' : Show.objects.all()
	}
	return render(request, "shows.html", context)

def rootRoute(request):

	return redirect('/shows')
	
def shows(request):
	
	
	return render(request, "new.html")

def createShow(request):
	resultFromValidator =  Show.objects.validateShow(request.POST)
	print('we are back in the views')
	print(resultFromValidator)
	print(len(resultFromValidator))
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
	newShow = Show.objects.create(title = request.POST['title'], network = request.POST['network'], release_date = request.POST['rdate'])
	
	return redirect("/shows/" + str(newShow.id))

def editShow(request, showid):
	showToShow =  Show.objects.get(id = showid)
	context = {
		'show': showToShow,
		'allShows': Show.objects.all()
	}
	
	return render(request, "edit.html", context)

def updateShow(request, showid):


	resultFromValidator =  Show.objects.validateShow(request.POST)
	print('we are back in the views')
	print(resultFromValidator)
	print(len(resultFromValidator))
	if len(resultFromValidator) > 0:
		for key, value in resultFromValidator.items():
			messages.error(request, value)
	
		return redirect('/shows/' + showid + '/edit')
	else:
		showToUpdate = Show.objects.get(id= showid)
		showToUpdate.title = request.POST['title']
		showToUpdate.network = request.POST['network']
		showToUpdate.release_date = request.POST['release_date']
		showToUpdate.save()
	
	return redirect("/shows/" + showid)

def showInfo(request, showid):
	showToShow =  Show.objects.get(id = showid)
	context = {
		'show': showToShow,
		'allShows': Show.objects.all()
		

	}
	return render(request, "showinfo.html", context)

def destroy(request, showid):
	showToDelete = Show.objects.get(id = showid)
	
	showToDelete.delete()


	return redirect('/shows')

	
