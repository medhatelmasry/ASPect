export const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;

export const nameRegex = /^[a-zA-Z]{2,20}$/;

export const passwordRegex = /^(?!.*[\s])(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[`~!@#$%^&*()\-=_+{}<>;:'",.?|\\/[\]]).{8,20}$/i;
