import { Specialization } from './specialization';
import { Department } from './department';
import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Roles } from './roles';
import { Login } from './login';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  //create an instance of Employee
  formData: Employee = new Employee();
  specializationForm: Specialization = new Specialization();
  loginForm: Login = new Login();
  departments: Department[];
  specializations: Specialization[];
  employees: Employee[];
  roles: Roles[];
  constructor(private httpClient: HttpClient) {}

  //GET department for binding
  getAllDepartments() {
    this.httpClient
      .get(environment.apiUrl + '/api/department')
      .toPromise()
      .then((response) => (this.departments = response as Department[]));
  }

  //GET specializations for binding
  getSpecializations() {
    this.httpClient
      .get(environment.apiUrl + '/api/department/getSpecializations')
      .toPromise()
      .then(
        (response) => (this.specializations = response as Specialization[])
      );
  }

  //GET roles for binding
  getAllRoles() {
    this.httpClient
      .get(environment.apiUrl + '/api/roles')
      .toPromise()
      .then((response) => (this.roles = response as Roles[]));
  }

  //insert employee
  insertEmployee(employee: Employee): Observable<any> {
    return this.httpClient.post(
      environment.apiUrl + '/api/employee/AddEmployee',
      employee
    );
  }

  //insert login details
  insertLogin(user: Login): Observable<any> {
    return this.httpClient.post(environment.apiUrl + '/api/login', user);
  }

  //insert specialization
  insertSpecialization(specialization: Specialization): Observable<any> {
    return this.httpClient.post(
      environment.apiUrl + '/api/department',
      specialization
    );
  }

  //update employee
  updateEmployee(employee: Employee): Observable<any> {
    return this.httpClient.put(
      environment.apiUrl + '/api/employee/UpdateEmployee',
      employee
    );
  }

  //get all employees
  getAllEmployee() {
    this.httpClient
      .get(environment.apiUrl + '/api/employee/GetEmployees')
      .toPromise()
      .then((response) => (this.employees = response as Employee[]));
  }

  //delete employee
  deleteEmployee(id: number) {
    return this.httpClient.delete(environment.apiUrl + '/api/employee/' + id);
  }

  //get a particular employee from
  getEmployee(empId: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/employee/GetEmployeeById?id=' + empId
    );
  }

  getDoctors(): Employee[]{
    return this.employees.filter(e => e.RoleId ==1);
  }
}
