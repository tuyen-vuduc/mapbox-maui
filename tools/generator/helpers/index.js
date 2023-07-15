export function camelCase(value) {
    if (!value || !(value.trim())) return '';

    var trimmedValue = value.trim();
    return trimmedValue[0].toLowerCase() + trimmedValue.substring(1);
}

export function pascalCase(value) {
    if (!value || !(value.trim())) return '';

    var trimmedValue = value.trim();
    return trimmedValue[0].toUpperCase() + trimmedValue.substring(1);
}