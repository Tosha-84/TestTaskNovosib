<script>

  export default {
    data() {
      return {
          city: "",
          factory: "",
          employee: "",
          brigade: "",
          workingShift: "",
      }
    },

    methods: {
      selectCity() {
        this.factory = ""
        this.employee = ""
      },

      selectFactory() {
        if ((this.factory == "Иркутский авиазавод") || (this.factory == "Иркутская плотина")) {
          this.city = "Иркутск"
        }
        else if ((this.factory == "Новосибирское метро") || (this.factory == "Новосибирские тортики")) {
          this.city = "Новосибирск"
        }
        else if ((this.factory == "Братская плотина") || (this.factory == "Братская любовь")) {
          this.city = "Братск"
        }
      },

      selectEmployee() {
        if ((this.employee == "Работник иркутского авиазавода №1") || (this.employee == "Работник иркутского авиазавода №2")) {
          this.city = "Иркутск"
          this.factory = "Иркутский авиазавод"
        }
        else if ((this.employee == "Работник иркутской плотины №1") || (this.employee == "Работник иркутской плотины №2")) {
          this.city = "Иркутск"
          this.factory = "Иркутская плотина"
        }
        else if ((this.employee == "Работник новосибирского метро №1") || (this.employee == "Работник новосибирского метро №2")) {
          this.city = "Новосибирск"
          this.factory = "Новосибирское метро"
        }
        else if ((this.employee == "Пекарь новосибирских тортиков №1") || (this.employee == "Пекарь новосибирских тортиков №2")) {
          this.city = "Новосибирск"
          this.factory = "Новосибирские тортики"
        }
        else if ((this.employee == "Работник братской плотины №1") || (this.employee == "Работник братской плотины №2")) {
          this.city = "Братск"
          this.factory = "Братская плотина"
        }
        else if ((this.employee == "Любовник братской любви №1") || (this.employee == "Любовник братской любви №2")) {
          this.city = "Братск"
          this.factory = "Братская любовь"
        }
      },

      clearCity() {
        this.city = ""
        this.factory = ""
        this.employee = ""
      },

      clearFactory() {
        this.factory = ""
        this.employee = ""
      },

      clearEmployee() {
        this.employee = ""
      },
      send() {
        if ((this.city != "") && (this.factory != "") && (this.employee != "") && (this.brigade != "") && (this.workingShift != ""))
        {
          document.cookie = encodeURIComponent("city") + '=' + encodeURIComponent(this.city);
          document.cookie = encodeURIComponent("factory") + '=' + encodeURIComponent(this.factory);
          document.cookie = encodeURIComponent("employee") + '=' + encodeURIComponent(this.employee);
          document.cookie = encodeURIComponent("brigade") + '=' + encodeURIComponent(this.brigade);
          document.cookie = encodeURIComponent("workingShift") + '=' + encodeURIComponent(this.workingShift);

          console.log(document.cookie);

        }
        else
        {
          alert("Все поля должны быть заполнены")
        }
      },

  }


}

</script>

<template>
  <header>
    <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />
  </header>

  <main>

    <div class="wrapper">
      
      <h1>Это заголовочный текст</h1>

      <h1>
      <select id="cities" placeholder="asdf" v-model="this.city" name="cities" @change="selectCity()">
        <option value="Иркутск">Иркутск</option>
        <option value="Новосибирск">Новосибирск</option>
        <option value="Братск">Братск</option>
      </select>
      <input type="button" @click="clearCity()" value="Очистить выбор">
      </h1>
    
      <h1>
      <select id="factories" v-model="this.factory" name="factories" @change="selectFactory()">
        <option value="Иркутская плотина" v-if="city == 'Иркутск' || city == ''">Иркутская плотина</option>
        <option value="Иркутский авиазавод" v-if="city == 'Иркутск' || city == ''">Иркутский авиазавод</option>

        <option value="Новосибирское метро" v-if="city == 'Новосибирск' || city == ''">Новосибирское метро</option>
        <option value="Новосибирские тортики" v-if="city == 'Новосибирск' || city == ''">Новосибирские тортики</option>

        <option value="Братская плотина" v-if="city == 'Братск' || city == ''">Братская плотина</option>
        <option value="Братская любовь" v-if="city == 'Братск' || city == ''">Братская любовь</option>
      </select>
      <input type="button" @click="clearFactory()" value="Очистить выбор">
      </h1>

      <h1>
      <select id="emplyees" v-model="this.employee" name="emplyees" @change="selectEmployee()">
        <option value="Работник иркутской плотины №1" v-if="((city == 'Иркутск' || city == '') && factory == '') || factory == 'Иркутская плотина'">Работник иркутской плотины №1</option>
        <option value="Работник иркутской плотины №2" v-if="((city == 'Иркутск' || city == '') && factory == '') || factory == 'Иркутская плотина'">Работник иркутской плотины №2</option>

        <option value="Работник иркутского авиазавода №1" v-if="((city == 'Иркутск' || city == '') && factory == '') || factory == 'Иркутский авиазавод'">Работник иркутского авиазавода №1</option>
        <option value="Работник иркутского авиазавода №2" v-if="((city == 'Иркутск' || city == '') && factory == '') || factory == 'Иркутский авиазавод'">Работник иркутского авиазавода №2</option>

        <option value="Работник новосибирского метро №1" v-if="((city == 'Новосибирск' || city == '') && factory == '') || factory == 'Новосибирское метро'">Работник новосибирского метро №1</option>
        <option value="Работник новосибирского метро №2" v-if="((city == 'Новосибирск' || city == '') && factory == '') || factory == 'Новосибирское метро'">Работник новосибирского метро №2</option>

        <option value="Пекарь новосибирских тортиков №1" v-if="((city == 'Новосибирск' || city == '') && factory == '') || factory == 'Новосибирские тортики'">Пекарь новосибирских тортиков №1</option>
        <option value="Пекарь новосибирских тортиков №2" v-if="((city == 'Новосибирск' || city == '') && factory == '') || factory == 'Новосибирские тортики'">Пекарь новосибирских тортиков №2</option>

        <option value="Работник братской плотины №1" v-if="((city == 'Братск' || city == '') && factory == '') || factory == 'Братская плотина'">Работник братской плотины №1</option>
        <option value="Работник братской плотины №2" v-if="((city == 'Братск' || city == '') && factory == '') || factory == 'Братская плотина'">Работник братской плотины №2</option>

        <option value="Любовник братской любви №1" v-if="((city == 'Братск' || city == '') && factory == '') || factory == 'Братская любовь'">Любовник братской любви №1</option>
        <option value="Любовник братской любви №2" v-if="((city == 'Братск' || city == '') && factory == '') || factory == 'Братская любовь'">Любовник братской любви №2</option>

      </select>
      <input type="button" @click="clearEmployee()" value="Очистить выбор">
      </h1>

      <h1>
      <div id="brigade">
        <input type="radio" id="Первая бригада" value="Первая бригада" v-model="brigade" />
        <label for="Первая бригада">Первая бриагда</label>
        <br />
        <input type="radio" id="Вторая бригада" value="Вторая бригада" v-model="brigade" />
        <label for="Вторая бригада">Вторая бригада</label>
        <br />
      </div>
    </h1>


      <h1>
      <select id="cities" v-model="this.workingShift" name="workingShift">
        <option value="1 час">1 час</option>
        <option value="2 часа">2 часа</option>
        <option value="3 часа">3 часа</option>
        <option value="4 часа">4 часа</option>
        <option value="5 часов">5 часов</option>
        <option value="6 часов">6 часов</option>
        <option value="7 часов">7 часов</option>
        <option value="8 часов">8 часов</option>
        <option value="9 часов">9 часов</option>
        <option value="10 часов">10 часов</option>
        <option value="11 часов">11 часов</option>
        <option value="12 часов">12 часов</option>
      </select>
      </h1>


      <p>Город: {{ city }}</p>
      <p>Организация: {{ factory }}</p>
      <p>Сотрудник: {{ employee }}</p>
      <p>Бригада: {{ brigade }} </p>
      <p>Смена: {{ workingShift }} </p>

      <h1>
        <input type="button" @click="send()" value="Отправить в cookie">
      </h1>


    </div>
    
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
