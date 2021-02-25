from django.http import HttpResponse
from . import matrixLib

def matrix_calc_request(request):
	content = matrixLib.handle(request)

	return HttpResponse(content, content_type='application/json')
