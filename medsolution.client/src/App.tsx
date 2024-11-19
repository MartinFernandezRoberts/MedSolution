import React, { useState, useEffect } from "react";
import axios from "axios";


const Procedimientos = () => {
    const [procedimientos, setProcedimientos] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:32769/api/ficha")
            .then(response => setProcedimientos(response.data))
            .catch(error => console.error(error));
    }, []);

    const desfirmar = (idFicha, tipo) => {
        axios.post("https://localhost:32769/api/ficha/desfirmar", {
            idFicha,
            fecha: "2024-11-19", // ejemplo
            rut: "12345678-9",   // ejemplo
            desfirmarInformeMedico: tipo === "medico",
            desfirmarInformeEnfermeria: tipo === "enfermeria"
        })
            .then(() => alert("Desfirmado correctamente"))
            .catch(error => console.error(error));
    };

    return (
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Paciente</th>
                    <th>Fecha</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                {procedimientos.map(proc => (
                    <tr key={proc.idFicha}>
                        <td>{proc.idFicha}</td>
                        <td>{proc.idPaciente}</td>
                        <td>{proc.fecha}</td>
                        <td>
                            <button onClick={() => desfirmar(proc.idFicha, "medico")}>Desfirmar Médico</button>
                            <button onClick={() => desfirmar(proc.idFicha, "enfermeria")}>Desfirmar Enfermería</button>
                            <button onClick={() => desfirmar(proc.idFicha, "ambos")}>Desfirmar Ambos</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default Procedimientos;