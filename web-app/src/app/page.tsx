'use client';

import { useEffect, useState } from 'react';
import { Employee } from './types/employee';

export default function Home() {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    fetch('http://localhost:5000/api/filter/get/employees')
      .then((res) => res.json())
      .then((data) => {
        const employeeArray: Employee[] = Object.values(data);
        setEmployees(employeeArray);
      })
      .catch((error) => console.error('Failed to fetch employees:', error));
  }, []);

  return (
    <div style={{ padding: '2rem' }}>
      <h1>Employees</h1>
      <div style={{ overflowX: 'auto', maxHeight: '500px', overflowY: 'scroll', border: '1px solid #ccc' }}>
        <table style={{ width: '100%', borderCollapse: 'collapse' }}>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Email</th>
              <th>Department</th>
              <th>Job Title</th>
              <th>City</th>
              <th>Country</th>
              <th>Salary</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((emp) => (
              <tr key={emp.id}>
                <td>{emp.id}</td>
                <td>{emp.firstName} {emp.lastName}</td>
                <td>{emp.email}</td>
                <td>{emp.department}</td>
                <td>{emp.jobTitle}</td>
                <td>{emp.city}</td>
                <td>{emp.country}</td>
                <td>{emp.salary}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
