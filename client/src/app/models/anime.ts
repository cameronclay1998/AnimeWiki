export interface Anime {
    id: string
    title: string
    releaseDate: string
    description: string
    authorFirstName: string
    authorLastName: string
    genres: string[],
    photos?: Photo[]
  }

  export const blankAnime = {
      id: '',
      title: '',
      releaseDate: '',
      description: '',
      authorFirstName: '',
      authorLastName: '',
      genres: []
  }

  export interface Photo {
    id: string;
    url: string;
    isMain: boolean;
  }
  