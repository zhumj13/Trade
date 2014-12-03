#include "stdafx.h"

#include <glut.h> 
#include <math.h>

#define PI 3.1415926
static int angleh = 0; 
static int anglev = 0;


void init()
{
	glClearColor(0.0,0.0,0.0,0.0);
	glShadeModel(GL_FLAT);
}
void display() 
{    
		glClear(GL_COLOR_BUFFER_BIT); 
		glColor3f(0,1,1);
		glLoadIdentity();
		gluLookAt(5 * sin(angleh * PI / 180) * cos(anglev * PI / 180),5*sin(anglev * PI / 180),5 * cos(angleh *PI / 180)*cos(anglev * PI / 180),0.0,0.0,0.0,0.0,1.0,0.0);
		glutSolidTeapot(1.0);
		glutSwapBuffers();  

}  

void reshape(int w,int h) 
{ 
	glViewport(0,0,(GLsizei)w,(GLsizei)h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60.0,(GLfloat)w/(GLfloat)h,1.0,20.0);
	glMatrixMode(GL_MODELVIEW);

}  

void keyboard(unsigned char key,int x,int y)
{
	switch(key)
	{
	case 'a':
		angleh = (angleh + 5) % 360;
		glutPostRedisplay();
		break;
	case 'w':
		anglev = (anglev + 5) % 360;
		glutPostRedisplay();
		break;
	case 'd':
		angleh = (angleh - 5 ) % 360;
		glutPostRedisplay();
		break;
	case 's':
		anglev = (anglev - 5 ) % 360;
		glutPostRedisplay();
		break;
		
	default :
		break;

	}
}

int main(int argc,char **argv)
{     
	glutInit(&argc,argv);    
	glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE);    
	glutInitWindowSize(500,500); 
	glutInitWindowPosition(100,100);

	glutCreateWindow(argv[0]); 
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard);
	glutMainLoop();    
	return 0;
}