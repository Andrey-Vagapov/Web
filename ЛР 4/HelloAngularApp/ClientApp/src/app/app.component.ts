import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Game } from './game';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    game: Game = new Game();   // изменяемый товар
    games: Game[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadGames();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadGames() {
        this.dataService.getGames()
            .subscribe((data: Game[]) => this.games = data);
    }
    // сохранение данных
    save() {
        if (this.game.id == null) {
            this.dataService.createGame(this.game)
                .subscribe((data: Game) => this.games.push(data));
        } else {
            this.dataService.updateGame(this.game)
                .subscribe(data => this.loadGames());
        }
        this.cancel();
    }
    editGame(p: Game) {
        this.game = p;
    }
    cancel() {
        this.game = new Game();
        this.tableMode = true;
    }
    delete(p: Game) {
        this.dataService.deleteGame(p.id)
            .subscribe(data => this.loadGames());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}