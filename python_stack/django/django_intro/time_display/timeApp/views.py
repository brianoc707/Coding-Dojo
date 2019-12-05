from django.shortcuts import render
from time import gmtime, strftime, localtime

# Create your views here.
def displayTime(request):
    context = {
        "time": strftime("%Y-%m-%d %I:%M %p", localtime())
    }
    
    return render(request,'index.html', context)