from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')          
def hello_world():
	return render_template("index.html")
	

@app.route('/<name>/<times>')
def hi(name, times):
	print(name, times)
	return render_template ("name.html", some_name = name, num_times = int(times))
	

@app.route('/repeat/<number>/<word>')
def repeat(number, word):
	return  word * int(number)

@app.errorhandler(404)
def not_found(e):	
	return ("Sorry! No response, Try Again.")
	  
if __name__=="__main__":       
	app.run(debug=True)