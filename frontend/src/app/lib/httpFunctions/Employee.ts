
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const addUrl = 'https://epmgapi.azurewebsites.net/api/employees';

export function addEmployee(http: HttpClient, formData: any): Observable<any[]> {
    const jsonData = {
        name: formData.name,
        email: formData.email,
        phone: `${formData.phonePart1}-${formData.phonePart2}-${formData.phonePart3}`,
        address: `${formData.address1} ${formData.address2}`,
        city: formData.city,
        state: formData.state,
        postalCode: formData.zipcode,
        roleId: 1,
        payGradeId: 1,
        personalInfo: {
            ssn: null,
            routingNumber: null,
            accountNumber: null,
            birthdate: null,
            hireDate: null
        },
        schedule: {
            mondayStart: null,
            mondayEnd: null,
            tuesdayStart: null,
            tuesdayEnd: null,
            wednesdayStart: null,
            wednesdayEnd: null,
            thursdayStart: null,
            thursdayEnd: null,
            fridayStart: null,
            fridayEnd: null,
            saturdayStart: null,
            saturdayEnd: null,
            sundayStart: null,
            sundayEnd: null
        }
    };
    return http.post<any[]>(addUrl, jsonData);
}


export function removeEmployee(http: HttpClient, id: any): Observable<any[]> {
    const removeUrl = `https://epmgapi.azurewebsites.net/api/employees/${id}`;
    console.log(removeUrl)
    return http.delete<any[]>(removeUrl);
}
