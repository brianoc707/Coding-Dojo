from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'potato'


@app.route('/')   
def forms():
	if 'totalGold' not in session:
		session['totalGold'] = 0
	return render_template("index.html", totalGold = session['totalGold'])


@app.route('/process_money' , methods = ['POST'])
def earned():
	print(request.form)
	print(request.form['building'])
	if request.form['building'] == 'Farm':
		goldEarned = random.randint(10, 20)
		goldEarned += session['totalGold']
	return redirect('/')

@app.errorhandler(404)
def not_found(e):	
	return ("Sorry! No response, Try Again.")
	  
if __name__=="__main__":       
	app.run(debug=True)