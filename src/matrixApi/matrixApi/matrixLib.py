from ctypes import * 
from . import matrixJson 

def multiply(a, b, a_columns, b_columns):
	so_file = "./matrixCalc.so"
	so_import = CDLL(so_file)
		
	a_len = len(a)
	b_len = len(b)

	mem_array_a = c_int * a_len
	mem_array_b = c_int * b_len

	matrix_a = mem_array_a(*a)
	matrix_b = mem_array_a(*b)
	
	a_rows = a_len // a_columns
	b_rows = b_len // b_columns

	c_len = a_rows * b_columns

	mem_array_c = c_int * c_len

	empty_c = [0 for i in range(c_len)] 
	
	matrix_c = mem_array_c(*empty_c)
	
	so_import.multiply(matrix_a, matrix_b, a_columns, b_columns, c_len, matrix_c)
	
	return matrix_c

def handle(request):
	matrices = matrixJson.deserialize_calc_request(request.body)
	
	a = matrices[0]
	b = matrices[1]
	
	c_entries = multiply(a.entries, b.entries, a.columns, b.columns)
	
	c_columns = b.columns

	return matrixJson.serialize_calc_response(c_entries, c_columns);

