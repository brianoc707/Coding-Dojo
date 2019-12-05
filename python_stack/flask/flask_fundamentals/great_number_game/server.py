from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'potato'


@app.route('/')   
def randomform():
	if 'randomnum' not in session:
		session['randomnum'] = random.randint(1,100)

	if 'result' not in session:
		session['result'] = ""

	if 'count' not in session:
		session['count'] = 0

	print(session['randomnum'])
	return render_template("index.html", result = session['result'], attempts = session['count'])

@app.route('/guess', methods = ['POST'])
def highorlow():
	print(request.form)
	guess = int(request.form['guess'])
	if guess > session['randomnum']:
		session['result'] = 'Too high'
		print('Too High!')
	if guess < session['randomnum']:
		session['result'] = 'Too Low'
		print('Too Low!')
	if guess == session['randomnum']:
		session['result'] = 'Correct!'
		print('Correct')
	return redirect('/')

@app.route('/playAgain')
def playagain():
	session.clear()
	return redirect('/')

@app.errorhandler(404)
def not_found(e):	
	return ("Sorry! No response, Try Again.")
	  
if __name__=="__main__":       
	app.run(debug=True)