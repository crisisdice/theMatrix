from django.urls import path
from . import views

urlpatterns = [
	path('api/v1/1multiply', views.matrix_calc_request, name='index'),
]
