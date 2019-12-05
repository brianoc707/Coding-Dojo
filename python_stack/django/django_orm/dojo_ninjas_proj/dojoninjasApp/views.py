from django.shortcuts import render, redirect
from .models import Ninja, Dojo
# Create your views here.
def home(request):
	context = {
		"allNinjas": Ninja.objects.all(),
		"allDojos": Dojo.objects.all()
	}
	return render(request,"index.html", context) 
def members(request, dojoid):
	
	
	dojoToShow = Dojo.objects.get(id = dojoid)
	context = {
		'dojo': dojoToShow
	} 
	return render(request, "members.html", context)