from flask import Flask, render_template
app = Flask(__name__)

@app.route('/play/<number>/<background_color>')
def displayBox(number, background_color):
    return render_template("index.html", some_num= int(number), some_color= background_color)

if __name__=="__main__":       
	app.run(debug=True)    