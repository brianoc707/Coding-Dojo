from django.shortcuts import render, redirect
import random
import datetime

# Create your views here.
def home(request):
	if 'totalGold' not in request.session:
		request.session['totalGold'] = 0
	if 'activityLog' not in request.session:
		request.session['activityLog'] = []
	print(request.session['activityLog'])
	return render(request, 'index.html')

def process(request):
	currentTime = datetime.datetime.now()
	if request.POST['building'] == 'Farm':
		goldEarned = random.randint(10, 20)
		request.session['totalGold'] += goldEarned
		request.session['activityLog'].append(f'Earned {goldEarned} from the Farm! {currentTime}')
	if request.POST['building'] == 'Cave':
		goldEarned = random.randint(5, 10)
		request.session['totalGold'] += goldEarned
		request.session['activityLog'].append(f'Earned {goldEarned} from the Cave! {currentTime}')
	if request.POST['building'] == 'House':
		goldEarned = random.randint(2, 5)
		request.session['totalGold'] += goldEarned
		request.session['activityLog'].append(f'Earned {goldEarned} from the House! {currentTime}')
	if request.POST['building'] == 'Casino':
		goldEarned = random.randint(-50, 50)
		request.session['totalGold'] += goldEarned
		if goldEarned < 0:
			request.session['activityLog'].append(f'Lost {goldEarned} at the Casino! {currentTime}')
		else:
			request.session['activityLog'].append(f'Earned {goldEarned} at the Casino! {currentTime}')   
	return redirect('/')


def reset(request):
	request.session.clear()
	return redirect('/')