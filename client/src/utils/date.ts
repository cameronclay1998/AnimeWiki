export const formatDate = (
    date: Date,
    locale: string = 'en-US',
    options?: Intl.DateTimeFormatOptions
  ): string => {
    const defaultOptions: Intl.DateTimeFormatOptions = {
      year: 'numeric',
      month: 'short',
      day: '2-digit',
    };
  
    return new Intl.DateTimeFormat(locale, {
      ...defaultOptions,
      ...options,
    }).format(date);
  };
  
  export const formatDateTime = (
    date: Date,
    locale: string = 'en-US'
  ): string => {
    return formatDate(date, locale, {
      year: 'numeric',
      month: 'short',
      day: '2-digit',
      hour: 'numeric',
      minute: '2-digit',
    });
  };
  