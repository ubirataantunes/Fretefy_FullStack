import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cidade } from '../models/cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {
  private apiUrl = `${environment.baseApiUrl}/cidade`;

  constructor(private http: HttpClient) { }
  
    listarTodos(): Observable<Array<Cidade>> {
      return this.http
        .get<Array<Cidade>>(this.apiUrl)
    }

    listarPorId(id: string): Observable<Array<Cidade>> {
      return this.http
        .get<Array<Cidade>>(this.apiUrl + '/' + id)
    }

    cadastrar(cidade: Cidade): Observable<Cidade> {
      return this.http
        .post<Cidade>(this.apiUrl, cidade)
    }

    atualizarLatitudeELongitude(): Observable<Array<Cidade>> {
      return this.http
        .get<Array<Cidade>>(this.apiUrl + '/AtualizarLatitudeELongitude')
    }

    atualizarLatitudeELongitudePorId(id: string): Observable<Array<Cidade>> {
      return this.http
        .get<Array<Cidade>>(this.apiUrl + '/AtualizarLatitudeELongitudePorId/' + id)
    }
}
