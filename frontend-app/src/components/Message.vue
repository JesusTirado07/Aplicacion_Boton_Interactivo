<style scoped>
button {
  margin: 10px;
  padding: 15px;
  background: linear-gradient(45deg, #ffcc00, #ff6600, #ff3300); 
  background-size: 400% 400%; 
  color: white;
  border: none;
  cursor: pointer;
  font-size: 16px;
  border-radius: 5px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  animation: fuego 2s infinite; 
  transition: all 0.3s ease;
}

button:hover {
  transform: scale(1.05);
}

button:active {
  transform: scale(0.98);
}

@keyframes fuego {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}

p {
  margin-top: 20px;
  font-size: 18px;
  color: #333;
  font-weight: bold;
  text-align: center;
  transition: opacity 0.5s ease;
}

.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s ease;
}

.fade-enter, .fade-leave-to {
  opacity: 0;
}

.container {
  max-width: 400px;
  margin: 50px auto;
  text-align: center;
  padding: 20px;
  background-color: #f9f9f9;
  border-radius: 10px;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
}
</style>

<template>
  <div class="container">
    <button @click="obtenerMensaje">Obtener mensaje</button>
    <transition name="fade">
      <p v-if="mensaje">{{ mensaje }}</p>
    </transition>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      mensaje: null,
    };
  },
  methods: {
    async obtenerMensaje() {
      try {
        const response = await axios.get("http://localhost:5296/api/mensaje");
        this.mensaje = response.data.mensaje;
      } catch (error) {
        console.error("Error al obtener el mensaje:", error);
      }
    },
  },
};
</script>

