from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string



# Create your views here.
def home(request):
    context = {
        'string' : get_random_string(length=14)
    }
    if 'counter' not in request.session:
         request.session['counter'] = 0
    else: 
        request.session['counter'] +=1
    return render(request,'index.html', context)

def reset(request):
    del request.session['counter']
    return redirect('/')