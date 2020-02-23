#include "main.h"

#define STEP 100;

char **get_names(char *, int *);

int main()
{
	char *strfile = "list.txt";
	FILE *pfile;
	struct stat st;
	FILE *log = fopen("log.txt", "w+");
	FILE *out;
	size_t fsize;

	char **file_names;

	int i = 0, j = 0;
	int count;
	char dest[30];
	file_names = get_names(strfile, &count);
	for (i = 0; i < count - 1; i++)
	{	
		int pos = strrchr(file_names[i], '/') - file_names[i] + 1;
		if (pos>0)
		{
			strncpy(dest, &file_names[i][pos], strlen(file_names[i]) - pos);
			strcat(dest, ".json");
		}
		else
		{
			strncpy(dest, file_names[i], strlen(file_names[i]));
			strcat(dest, ".json");
		}
		

		printf("Opening %s\n", file_names[i]);
		pfile = fopen(file_names[i], "r");
		out = fopen(dest, "w");

		fstat(fileno(pfile), &st);
		fsize = st.st_size;
		printf("File size: %d\n", (int)fsize);
		if(fsize == 0)
			continue;
		
		char *data = malloc(fsize + 2);
		memset(data, 0x0, fsize + 2);
		fread(data, fsize, 1, pfile);

		int nofkeys;
		memcpy(&nofkeys, &data[0], sizeof(int));
		fprintf(log, "Found %d keys in %s\n", nofkeys, file_names[i]);
		int sblock_size = nofkeys * 30;
		int entry_sizes[nofkeys];
		int dblock_size = 0;
		int ddblock_size = 0;
		int offset = 4;
		char keys[nofkeys][30];
		
		for(j = 0; j < nofkeys; j++, offset += 30)
		{
			strcpy(keys[j], &data[offset]);
		}

		for(j = 0; j < nofkeys; j++, offset+=4)
		{
			memcpy(&entry_sizes[j], &data[offset], sizeof(int));
			dblock_size += entry_sizes[j];
		}
		for(j = 0; j < nofkeys; j++)
		{
			fprintf(log, "\t%s\t", keys[j]);
			fprintf(log, "\t\tlength : %d \n", entry_sizes[j]);
		}

		fprintf(log, "Data block size : %d\n", dblock_size);
		char* value;
		int temp;
		char flag;
		fprintf(out, "{\n");
		while(offset < fsize)
		{	
			for(j = 0; j < nofkeys && offset < fsize; j++)
			{	
				
				if(entry_sizes[j] == 1)
				{
					value = (char *)malloc(20);
					memcpy(&flag, &data[offset], entry_sizes[j]);
					if(flag == 1)
						sprintf(value, "%s" , "true");
					else
						sprintf(value, "%s" , "false");
					
					if(j != nofkeys - 1)
						fprintf(out, "\t\"%s\" : %s,\n", keys[j], value);
					else
						fprintf(out, "\t\"%s\" : %s\n},\n", keys[j], value);
				}
				else if(entry_sizes[j] == 4)
				{
					value = (char *)malloc(20);
					memcpy(&temp, &data[offset], entry_sizes[j]);
					sprintf(value, "%d" , temp);
					if(j != nofkeys - 1)
						fprintf(out, "\t\"%s\" : %s,\n", keys[j], value);
					else
						fprintf(out, "\t\"%s\" : %s\n},\n", keys[j], value);
				}
				else
				{
					value = (char *)malloc(entry_sizes[j]+1);
					strncpy(value, &data[offset], entry_sizes[j]);
					value[100] = '\0';
					if(j != nofkeys - 1)
						fprintf(out, "\t\"%s\" : \"%s\",\n", keys[j], value);
					else 
						fprintf(out, "\t\"%s\" : \"%s\"\n},\n", keys[j], value);
				}
				offset += entry_sizes[j];
				
				free(value);
				temp = 0;
			}
			
		}

		fclose(out);
		fclose(pfile);
		memset(dest, 0, sizeof(dest));
		free(data);
	}
	fclose(log);
	scanf("%d", &i);
	return 0;
}

char **get_names(char *name, int *lenght)
{
	char **ret;
	FILE *list = fopen(name, "r");
	int i = 0;
	int arrlen = STEP;

	if (list)
	{
		char **lines = (char **)malloc(arrlen * sizeof(char *));
		char buff[512];
		while (fgets(buff, sizeof(buff), list))
		{
			if (i == arrlen)
			{
				arrlen += STEP;
				char **nlines = (char **)realloc(lines, arrlen * sizeof(char *));
				if (nlines == NULL)
				{
					exit(1);
				}
				lines = nlines;
			}
			buff[strlen(buff) - 1] = '\0';
			int len = strlen(buff);

			char *str = (char *)malloc((len + 1) * sizeof(char));
			strcpy(str, buff);

			lines[i] = str;
			i++;
		}
		ret = lines;
	}
	else
		ret = NULL;
	*lenght = i;

	return ret;
}

/*
		//printf("%c", data[fsize - cursor_pos]);

		if (data[cursor_pos] != mask[0])
			cursor_pos++;
		else if (data[cursor_pos + 1] != mask[1])
			cursor_pos++;
		else if (data[cursor_pos + 2] != mask[2])
			cursor_pos++;
		else if (data[cursor_pos + 3] != mask[3])
			cursor_pos++;
		else
		{
			memcpy(&foutsize, &(data[cursor_pos - 4]), 4);
			//foutsize = fsize - cursor_pos - byteswritten;
			//byteswritten = foutsize + byteswritten;
			int pos = strrchr(file_names[j], '/') - file_names[j] + 1;
			char dest[64];
			strncpy(dest, &file_names[j][pos], strlen(file_names[j]) - pos);
			fprintf(log, "Dumping %s found at 0x%d which has %d bytes\n", dest, (int)cursor_pos, (int)foutsize);
			out = fopen(dest, "w");
			fwrite(&data[cursor_pos], foutsize, 1, out);
			fclose(out);
			memset(dest, 0, sizeof(dest));
			//out.write(&(data[cursor_pos - sizeof(mask)]), foutsize);
			cursor_pos += foutsize;
			j++;
*/