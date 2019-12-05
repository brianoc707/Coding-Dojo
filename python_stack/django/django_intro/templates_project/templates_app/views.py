from django.shortcuts import render

# Create your views here.
def home(request):
    return render(request, 'index.html')

def index(request):
    context = {
        'name': 'Noelle',
        'favorite_color': 'turquoise',
        'pets': ['Bruce,', 'Fitz', 'Georgie']
    }
    return render(request, 'index.html', context)