import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, map } from 'rxjs';
import { environment } from '../../../../../environments/environment';
import { CommonBasicSetup } from '../models/common-basic-setup';
import { SelectedModel } from '../../../../core/models/selectedModel';

@Injectable()
export class GenderService {
  cachedData: any[] = [];
  baseUrl = environment.apiUrl;
  gender: CommonBasicSetup;
  constructor(private http: HttpClient) {
    this.gender = new CommonBasicSetup();
   }

   
   getGenderDetails(id: number):Observable<CommonBasicSetup> {
    return this.http.get<CommonBasicSetup>(this.baseUrl + '/gender/get-GenderDetail/' + id);
  }
  // getAll():Observable<Gender[]> {
  //   return this.http.get<Gender[]>(this.baseUrl + '/gender/get-gender');
  // }
  getAllGenders(): Observable<CommonBasicSetup[]> {
    if (this.cachedData.length > 0) {
      // If data is already cached, return it without making a server call
      return of(this.cachedData);
    } else {
      // If data is not cached, make a server call to fetch it
      return this.http
        .get<CommonBasicSetup[]>(this.baseUrl + '/gender/get-allGender')
        .pipe(
          map((data) => {
            this.cachedData = data; // Cache the data
            return data;
          })
        );
    }
  }
  getSelectedGender() {
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gender/get-selectedGenders');
  }
  getGenderLastPosition() {
    return this.http.get<number>(this.baseUrl + '/gender/get-GenderLastPosition');
  }

  update(id: number,model: CommonBasicSetup): Observable<CommonBasicSetup> {
    return this.http.put<CommonBasicSetup>(this.baseUrl + '/gender/update-Gender/'+id, model);
  }
  submit(model: CommonBasicSetup): Observable<CommonBasicSetup> {
    return this.http.post<CommonBasicSetup>(this.baseUrl + '/gender/save-Gender', model);
  }
  delete(id:number): Observable<CommonBasicSetup>{
    return this.http.delete<CommonBasicSetup>(this.baseUrl + '/gender/delete-Gender/'+id);
  }
}
