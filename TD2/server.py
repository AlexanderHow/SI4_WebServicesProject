from http.server import BaseHTTPRequestHandler, HTTPServer	
import os
import subprocess
  
#Create custom HTTPRequestHandler class	 
class KodeFunHTTPRequestHandler(BaseHTTPRequestHandler):  

	#handle GET command  
	def do_GET(self):
		rootdir = '.'
		print(self.path)
		try:
			uri_decompose = self.path.split('?')
			name_php = uri_decompose[0]
			parameters = list()
			
			for p in uri_decompose[1].split('&'):
				parameters.append(p.replace('=',':'))
					
			cmd = "php ."+name_php+" "+json.dumps(parameters)
			ret = subprocess.Popen(cmd, shell=True,stdout=subprocess.PIPE)
			
			
			#send code 200 response	 
			self.send_response(200)	 
	  
			#send header first	
			self.send_header('Content-type','text-html')  
			self.end_headers()	

			self.wfile.write(ret.communicate()[0].encode())
			return	

		except IOError:	 
		  self.send_error(404, 'file not found')  

def run():	
  print('http server is starting...')	
  server_address = ('127.0.0.1', 8080)	
  httpd = HTTPServer(server_address, KodeFunHTTPRequestHandler)	 
  print('http server is running...')  
  httpd.serve_forever()	 

if __name__ == '__main__':	
  run() 