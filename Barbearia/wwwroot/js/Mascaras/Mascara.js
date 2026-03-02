const formatarTelefone = (valor) => {
    if (!valor) return "";
    valor = valor.replace(/\D/g, "");
    valor = valor.replace(/^(\d{2})(\d)/g, "($1) $2");
    valor = valor.replace(/(\d{5})(\d{4})$/, "$1-$2");
    return valor;
}

const formatarCpf = (valor) => {
    if (!valor) return "";
    valor = valor.replace(/\D/g, "");
    valor = valor.replace((/(\d{3})(\d)/, "$1.$2"));
    valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
    valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
    valor = valor.replace(/(\d{3})(\d{1,2})$/, "$1-$2");
    return valor;
}
    
const inputTelefone = document.getElementById("Telefone");
const inputCpf = document.getElementById("Cpf");

window.addEventListener('DOMContentLoaded', () => {
    if (inputTelefone) inputTelefone.value = formatarTelefone(inputTelefone.value);
    if (inputCpf) inputCpf.value = formatarCpf(inputCpf.value);
});

inputTelefone?.addEventListener('input', (event) => {
    event.target.value = formatarTelefone(event.target.value);
});

inputCpf?.addEventListener('input', (event) => {
    event.target.value = formatarCpf(event.target.value);
});

