from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = 'accountinfo'

@app.route('/')   
def login():
	return render_template("index.html")

@app.route('/result', methods=['POST'])
def newUser():
	print(request.form)
	session['forminfo'] = request.form
	return redirect("/showinfo")
	

@app.route('/showinfo')
def showinfo():
	print(session['forminfo'])
	return render_template("result.html", forminfo = session['forminfo'])  

@app.errorhandler(404)
def not_found(e):	
	return ("Sorry! No response, Try Again.")
	  
if __name__=="__main__":       
	app.run(debug=True)