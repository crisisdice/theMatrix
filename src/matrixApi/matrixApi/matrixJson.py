import json

def deserialize_calc_request(body):
	json_obj = json.loads(body)	

	a_json = json_obj["matrixA"]
	b_json = json_obj["matrixB"]
	
	a = Matrix(a_json)
	b = Matrix(b_json)

	return (a, b)

def serialize_calc_response(entries, columns):
	stringified_entries = ', '.join([str(i) for i in entries])
	template = '{{ "matrixC": {{ "entries": [ {0} ], "columns": {1} }} }}'
	
	return template.format(stringified_entries, columns)

class Matrix(object):
	def __init__(self, j):
		self.entries = j["entries"]
		self.columns = j["columns"]
