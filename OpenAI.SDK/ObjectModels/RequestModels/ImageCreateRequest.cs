using System.Text.Json.Serialization;
using Betalgo.Ranul.OpenAI.ObjectModels.SharedModels;

namespace Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;

/// <summary>
///     Image Create Request Model
/// </summary>
public record ImageCreateRequest : SharedImageRequestBaseModel, IOpenAIModels.IUser
{
    public ImageCreateRequest()
    {
    }

    public ImageCreateRequest(string prompt)
    {
        Prompt = prompt;
    }

    /// <summary>
    ///     A text description of the desired image(s). The maximum length is 1000 characters for dall-e-2 and 4000 characters
    ///     for dall-e-3
    /// </summary>
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    /// <summary>
    ///     The quality of the image that will be generated. Possible values are 'standard' or 'hd' (default is 'standard').
    ///     Hd creates images with finer details and greater consistency across the image.
    ///     This param is only supported for dall-e-3 model.
    ///     <br /><br />Check <see cref="StaticValues.ImageStatics.Quality" /> for possible values
    /// </summary>
    [JsonPropertyName("quality")]
    public string? Quality { get; set; }

    /// <summary>
    ///     The style of the generated images. Must be one of vivid or natural.
    ///     Vivid causes the model to lean towards generating hyper-real and dramatic images.
    ///     Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for
    ///     dall-e-3.
    ///     <br /><br />Check <see cref="StaticValues.ImageStatics.Style" /> for possible values
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style { get; set; }
}

public record GptImageCreateRequest : IOpenAIModels.IUser
{
    public GptImageCreateRequest()
    {
    }
    
    public GptImageCreateRequest(string prompt, string outputFormat)
    {
        Prompt = prompt;
        OutputFormat = outputFormat;
    }
    
    [JsonPropertyName("model")]
    public string Model { get; set; } = "gpt-image-1";
    
    /// <summary>
    /// Must be one of png, jpeg, or webp.
    /// </summary>
    [JsonPropertyName("output_format")]
    public string OutputFormat { get; set; }
    
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    /// <summary>
    ///     Possible values: low, medium, high.
    /// </summary>
    [JsonPropertyName("quality")]
    public string? Quality { get; set; } 
    
    /// <summary>
    /// Must be one of transparent, opaque or auto (default value).
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }
    
    /// <summary>
    /// Must be either low for less restrictive filtering or auto (default value).
    /// </summary>
    [JsonPropertyName("moderation")]
    public string Moderation { get; set; }
    
    /// <summary>
    /// The compression level (0-100%) for the generated images. This parameter is only supported the webp or jpeg output formats, and defaults to 100.
    /// </summary>
    [JsonPropertyName("output_compression")]
    public int? OutputCompression { get; set; }
    
    /// <summary>
    /// Must be one of 1024x1024, 1536x1024 (landscape), 1024x1536 (portrait), or auto (default value) 
    /// </summary>
    [JsonPropertyName("size")]
    public string? Size { get; set; } = "1024x1024";
    
    /// <summary>
    ///     The number of images to generate. Must be between 1 and 10.
    /// </summary>
    [JsonPropertyName("n")]
    public int? N { get; set; }
    
    /// <inheritdoc cref="SharedImageRequestBaseModel.User"/>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}